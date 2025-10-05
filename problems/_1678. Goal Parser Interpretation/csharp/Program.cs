using System.Text;

public class Solution
{
    public string Interpret(string command)
    {
        var sb = new StringBuilder();

        for (var i = 0; i < command.Length;)
            if (command[i] == 'G')
            {
                sb.Append("G");
                i++;
            }
            else
            {
                i++;
                if (command[i] == ')')
                {
                    sb.Append("o");
                    i++;
                }
                else
                {
                    sb.Append("al");
                    i += 3;
                }
            }

        return sb.ToString();
    }
}