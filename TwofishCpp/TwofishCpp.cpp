#define _CRT_SECURE_NO_WARNINGS
#define _SCL_SECURE_NO_WARNINGS
// TwofishCpp.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include "aes.h"
#include <time.h>

#define BUFFER_SIZE 1024

int main(int argc, char* argv[])
{
	keyInstance ki; /* use ki.keyDwords as key bits */
	cipherInstance ci; /* use ci.iv as iv bits */
	int keySize = 128; /* key size in bits */

	BYTE dir = DIR_ENCRYPT;
	BYTE mode = MODE_ECB;
	char IV[64]="00000000000000000000000000000000";
	char keyMaterial[64]="00000000000000000000000000000000";
	char* input_file_name = "input.txt";
	char* output_file_name = "output.txt";
	int buffer_size = BUFFER_SIZE;
	for (int i = 1; i < argc; i++)
	{
		if (strcmp(argv[i], "--encrypt") == 0) dir = DIR_ENCRYPT ;
		else if (strcmp(argv[i], "--decrypt") == 0) dir = DIR_DECRYPT;
		else if (strcmp(argv[i], "--buffer") == 0) buffer_size = atoi(argv[++i])*16;
		else if (strcmp(argv[i], "--mode") == 0)
		{
			i++;
			if (strcmp(argv[i], "ecb") == 0) mode = MODE_ECB ;
			else if (strcmp(argv[i], "cbc") == 0) mode = MODE_CBC ;
		}
		else if (strcmp(argv[i], "--keysize") == 0) keySize = atoi(argv[++i]);
		else if (strcmp(argv[i], "--key") == 0) strncpy(keyMaterial, argv[++i], sizeof(keyMaterial));
		else if (strcmp(argv[i], "--iv") == 0) strncpy(IV, argv[++i], sizeof(IV));
		else if (strcmp(argv[i], "--input") == 0) input_file_name = argv[++i];
		else if (strcmp(argv[i], "--output") == 0) output_file_name = argv[++i];
	}
	cipherInit(&ci, mode, IV);
	makeKey(&ki, dir, keySize, keyMaterial);
	BYTE *inputBuffer = (BYTE*)malloc(buffer_size);
	BYTE *outputBuffer = (BYTE*)malloc(buffer_size);
	FILE* fi = fopen(input_file_name, "rb");
	FILE* fo = fopen(output_file_name, "wb");

	clock_t t = clock();
	long total = 0;

	for (int length = fread(inputBuffer, 1, buffer_size, fi);
	     length > 0;
		 length = fread(inputBuffer, 1, buffer_size, fi))
	{
		for (int i = length&((BLOCK_SIZE / 8) - 1); i > 0 && i < (BLOCK_SIZE / 8); i++)
			inputBuffer[length++] = '\0';
		if (mode == MODE_ECB)
		{
			
			if (dir == DIR_ENCRYPT)
			{
#pragma omp parallel for
				for (int j = 0; j < length; j += 16)
					blockEncrypt(&ci, &ki, &inputBuffer[j], BLOCK_SIZE, &outputBuffer[j]);
			}
			if (dir == DIR_DECRYPT)
			{
#pragma omp parallel for
				for (int j = 0; j < length; j += 16)
					blockDecrypt(&ci, &ki, &inputBuffer[j], BLOCK_SIZE, &outputBuffer[j]);
			}
		}
		if (mode == MODE_CBC)
		{
			if (dir == DIR_ENCRYPT) blockEncrypt(&ci, &ki, inputBuffer, length * 8, outputBuffer);
			if (dir == DIR_DECRYPT) blockDecrypt(&ci, &ki, inputBuffer, length * 8, outputBuffer);
		}
		fwrite(outputBuffer, 1, length, fo);
		total += length;
	}
	t = clock() - t;
	printf("%d %lf\n", buffer_size, 1000.0*t / CLOCKS_PER_SEC / total);

	free(inputBuffer);
	free(outputBuffer);

	return 0;
}
