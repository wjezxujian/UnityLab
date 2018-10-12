#include <iostream>
#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include "TutorialConfig.h"

#ifdef USE_MYMATH
#include "MathFunctions/MathFunctions.h"
#endif

int main(int argc, char* argv[])
{
	if (argc < 2)
	{
		fprintf(stdout, "%s Version %d.%d\n", argv[0], Tutorial_VERSION_MAJOR, Tutorial_VERSION_MINOR);
		fprintf(stdout, "Usage: %s number\n", argv[0]);
		return 1;
	}

	double inputValue = atof(argv[1]);

#ifdef USE_MYMATH
	fprintf(stdout, "SWORD XU\n");
	double outputValue = mysqrt(inputValue);
#else
	fprintf(stdout, "SWORD XU2\n");
	double outputValue = sqrt(inputValue);
#endif

	fprintf(stdout, "The square root of %g is %g\n", inputValue, outputValue);

	char abc[10];
	std::cin >> abc;

	return 0;
}

  
//int main(int argc, char* argv[])
//{
//    std::cout << "Hello" << std::endl;
//}