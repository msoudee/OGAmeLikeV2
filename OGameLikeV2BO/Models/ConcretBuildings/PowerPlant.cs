using System;
using System.Collections.Generic;

namespace OGameLikeV2BO.Models.ConcretBuildings
{
    class PowerPlant : ResourceGenerator
    {
        public override List<Resource> TotalCost
        {
            get
            {
                List<Resource> res = new List<Resource>();

                Resource energie = new Resource { Name = ResourceType.ENERGY.ToString(), LastUpdate = DateTime.Now, LastQuantity = 0 };
                Resource oxygene = new Resource { Name = ResourceType.OXYGEN.ToString(), LastUpdate = DateTime.Now, LastQuantity = 0 };
                Resource acier = new Resource { Name = ResourceType.STEEL.ToString(), LastUpdate = DateTime.Now, LastQuantity = 0 };
                Resource uranium = new Resource { Name = ResourceType.URANIUM.ToString(), LastUpdate = DateTime.Now, LastQuantity = 0 };

                for (int nivTemp = 1; nivTemp <= Level; nivTemp++)
                {
                    energie.LastQuantity += calculerCoutNiveauEnergie(nivTemp);
                    oxygene.LastQuantity += calculerCoutNiveauOxygene(nivTemp);
                    acier.LastQuantity += calculerCoutNiveauAcier(nivTemp);
                    uranium.LastQuantity += calculerCoutNiveauUranium(nivTemp);
                }

                res.Add(energie);
                res.Add(oxygene);
                res.Add(acier);
                res.Add(uranium);

                return res;
            }
        }

        public override List<Resource> NextCost
        {
            get
            {
                List<Resource> res = new List<Resource>();

                res.Add(new Resource { Name = ResourceType.ENERGY.ToString(), LastUpdate = DateTime.Now, LastQuantity = calculerCoutNiveauEnergie(Level + 1) });
                res.Add(new Resource { Name = ResourceType.OXYGEN.ToString(), LastUpdate = DateTime.Now, LastQuantity = calculerCoutNiveauOxygene(Level + 1) });
                res.Add(new Resource { Name = ResourceType.STEEL.ToString(), LastUpdate = DateTime.Now, LastQuantity = calculerCoutNiveauAcier(Level + 1) });
                res.Add(new Resource { Name = ResourceType.URANIUM.ToString(), LastUpdate = DateTime.Now, LastQuantity = calculerCoutNiveauUranium(Level + 1) });

                return res;
            }
        }

        public override List<Resource> ResourceBySecond
        {
            get
            {
                List<Resource> res = new List<Resource>();
                res.Add(new Resource { Name = ResourceType.ENERGY.ToString(), LastUpdate = DateTime.Now, LastQuantity = ((3 * Level) + 10) });
                return res;
            }
        }

        private int? calculerCoutNiveauEnergie(int? niv)
        {
            return niv;
        }

        private int? calculerCoutNiveauOxygene(int? niv)
        {
            return (niv + (200 * (niv / 10)) + 20);
        }

        private int? calculerCoutNiveauAcier(int? niv)
        {
            return (niv + (100 * (niv / 8)) + 20);
        }

        private int? calculerCoutNiveauUranium(int? niv)
        {
            return (int)((3 * Math.Pow((Double)niv, 3)) + (200 * (niv / 20)) + 20);
        }
    }
}
