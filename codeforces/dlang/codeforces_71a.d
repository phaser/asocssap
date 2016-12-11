import std.stdio;
import std.conv;

int main(string[] argv)
{
	string nstr = stdin.readln();
	nstr.length -= 1;
	int n = to!int(nstr);
	for (int i = 0; i < n; i++)
	{
		string l = stdin.readln();
		if (l[l.length - 1] == '\n')
			l.length -= 1;
		if (l.length > 10)
		{
			string r = "" ~ l[0];
			r ~= to!string(l.length - 2);
			r ~= l[l.length - 1];
			writeln(r);
		} else {
			writeln(l);
		}
	}
    return 0;
}
