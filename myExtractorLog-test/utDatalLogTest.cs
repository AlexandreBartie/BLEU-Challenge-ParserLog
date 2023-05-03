using app.data;

namespace myappxunit;

public class DataLogTest
{

    private DataLog data = new();

    private

    [Fact]
    public void TST01_ListLooted(string input, string expected)
    {

        data.Load("")  = new(input);

        Assert.Equal(expected, list.txt);

    }


}