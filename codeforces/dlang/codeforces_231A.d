import std.stdio;
import core.stdc.stdio;

int main(string[] argv)
{
	int n;
	int a, b, c;
	scanf("%d", &n);
	int noproblems = 0;
	for (int i = 0; i < n; i++)
	{
		scanf("%d %d %d", &a, &b, &c);
		noproblems += (a + b + c) > 1 ? 1 : 0; 
	}
	printf("%d", noproblems);
    return 0;
}
