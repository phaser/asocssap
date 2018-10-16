#include <cstdio>

int main(void)
{
	int tcc, a, b;
	scanf("%d", &tcc);
	for (int i = 0; i < tcc; i++)
	{
		scanf("%d %d", &a, &b);
		printf("%s\n", a < b ? "<" : a == b ? "=" : ">");
	}
	return 0;
}
