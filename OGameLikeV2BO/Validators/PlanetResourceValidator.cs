using OGameLikeV2BO.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OGameLikeV2BO.Validators
{
    public class PlanetResourceValidator : ValidationAttribute
    {
        public class PlanetResourcesValidator : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                bool result = true;

                try
                {
                    List<Resource> resources = value as List<Resource>;
                    if (resources.Count != 4)
                    {
                        result = false;
                    }

                    bool energyBool = false;
                    bool oxygenBool = false;
                    bool steelBool = false;
                    bool uraniumBool = false;

                    resources.ForEach((x) =>
                    {
                        if (ResourceType.ENERGY.ToString() == x.Name)
                        {
                            energyBool = true;
                        }
                        else if (ResourceType.OXYGEN.ToString() == x.Name)
                        {
                            oxygenBool = true;
                        }
                        else if (ResourceType.STEEL.ToString() == x.Name)
                        {
                            steelBool = true;
                        }
                        else if (ResourceType.URANIUM.ToString() == x.Name)
                        {
                            uraniumBool = true;
                        }
                    });

                    if (!(energyBool && oxygenBool && steelBool && uraniumBool))
                    {
                        result = false;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    result = false;
                }

                return result;
            }
        }
    }
}
