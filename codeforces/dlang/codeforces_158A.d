import std.stdio;
import core.stdc.stdio;
import std.conv;
import std.container;

int main(string[] argv)
{
	int n, k;
	scanf("%d %d", &n, &k);
	int[] contestants = new int[n];
	for (int i = 0; i < n; i++)
	{
		scanf("%d", &contestants[i]);
	}
	int score = contestants[k-1];
	int result = 0;
	for (int i = 0; i < n; i++)
	{
		result += (contestants[i] > 0 && contestants[i] >= score) ? 1 : 0;
	}
	writeln(result);
	return 0;
}
