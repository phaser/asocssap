import std.stdio;
import core.stdc.stdio;
import std.conv;
import std.container;
import std.ascii;

int main(string[] argv)
{
	string word = readln();
	if (word[word.length - 1] == '\n') word.length -= 1; // eliminate new line if it exists
	string result = "";
	for (int i = 0; i < word.length; i++)
	{
		if (!(toLower(word[i]) == 'a' 
	       || toLower(word[i]) == 'e'
		   || toLower(word[i]) == 'i'
		   || toLower(word[i]) == 'o'
		   || toLower(word[i]) == 'u'
		   || toLower(word[i]) == 'y'))
		{
			result ~= "." ~ toLower(word[i]);
		}
	}
	writeln(result);
	return 0;
}
