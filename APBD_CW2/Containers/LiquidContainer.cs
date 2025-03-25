﻿using APBD_CW2.Interfaces;

namespace APBD_CW2.Containers;

public class LiquidContainer(
    double height,
    double weight,
    double depth,
    double maxLoad,
    bool isLoadHazardous
    )
    : Container(height, weight, depth, maxLoad, 'L'), IHazardNotifier
{
    
    public bool IsLoadHazardous { get; set; } = isLoadHazardous;

    public void SendTextNotification()
    {
        Console.WriteLine($"A hazardous situation has happened! Container: {SerialNumber}");
    }

    public override void Load(double loadMass)
    {
        
        
        double allowedMaxLoad = CalculateMaxAllowedLoad(CalculateMaxLoadModifier());
        
        if (allowedMaxLoad - loadMass < 0)
        {
            SendTextNotification();
        } 
        else
        {
            CargoMass = loadMass;
        }
        
    }
    
    private double CalculateMaxLoadModifier()
    {
        return IsLoadHazardous ? 0.5 : 0.9;
    }

    private double CalculateMaxAllowedLoad(double maxLoadModifier)
    {
        return Math.Round(MaxLoad * maxLoadModifier, 2);
    }

    public override string ToString()
    {
        return base.ToString() + $"  is load hazardous: {IsLoadHazardous}]";
    }
}