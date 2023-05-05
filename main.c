#include <stdio.h>
#include <stdlib.h>

int main(int argc, char* argv[]) {
	if (argc != 3) {
		printf("2 command line arguments required");
		return 0;
	}

	char* input_filename = argv[1];
	char* output_filename = argv[2];

	FILE* input_file = fopen(input_filename, "rb");
	if (input_file == NULL) {
		printf("cannot open '%s'", input_filename);
		return 0;
	}

	fseek(input_file, 0, SEEK_END);
	int file_size = ftell(input_file);
	rewind(input_file);

	if (file_size == 0) {
		printf("input file is empty");
		return;
	}

	char* bytes = (char* )malloc(file_size * sizeof(char));
	fread(bytes, file_size, 1, input_file);
	fclose(input_file);

	FILE* output_file = fopen(output_filename, "wb");
	if (output_file == NULL) {
		printf("cannot open or create '%s'", output_filename);
		return 0;
	}

	char* reversed_bytes = (char* )malloc(file_size * sizeof(char));
	for (int i = 0; i < file_size; i++) {
		reversed_bytes[i] = bytes[file_size - i - 1];
	}

	fwrite(reversed_bytes, file_size, 1, output_file);
	fclose(output_file);
	return 0;
} 