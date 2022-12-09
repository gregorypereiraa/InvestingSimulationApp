using System.ComponentModel.DataAnnotations;

namespace InvestProject.Models;

public class InvestModel
{
    [Required] [Range(1, 5000)] public int WeekInvesting { get; set; } = 200;

    [Required] [Range(1, 100)] public double Yield { get; set; } = 10;

    [Required] [Range(1, 100)] public double Years { get; set; } = 40;

    public double StartBalance { get; set; } = 0;


    public List<double> TotalBalance()
    {
        var output = new List<double>
        {
            StartBalance
        };
        for (var i = 1; i < Years + 1; i++)
        {
            var invested = output[i - 1] + YearInvesting();
            var totalBalance = invested + output[i - 1] * (Yield * 0.01);
            output.Add(totalBalance);
        }

        return output;
    }

    private double YearInvesting()
    {
        var output = WeekInvesting * 52.1429;
        return output;
    }

    public List<double> CoumpoundInterest(List<double> total)
    {
        var output = new List<double>();
        for (var i = 0; i < Years + 1; i++) output.Add(total[i] - InvestingYears()[i]);

        return output;
    }

    public List<double> InvestingYears()
    {
        var output = new List<double>
        {
            StartBalance
        };
        for (var i = 1; i < Years + 1; i++)
        {
            var totalInvested = output[i - 1] + YearInvesting();
            output.Add(totalInvested);
        }

        return output;
    }
}