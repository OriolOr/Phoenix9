using OriolOr.Maneko.API.Service.Interfaces;

namespace OriolOr.Maneko.API.Service;

public class MortageService : IMortageService
{
    public int GetTotalMortage()
    {
        return 320000;
    }
    
    public int GetAmortizedMortage()
    {
        return 1200;
    }
}