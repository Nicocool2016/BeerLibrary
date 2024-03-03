using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerLibrary
{
    public class BeersRepository
    {
        private List<Beer> _beers;

        public BeersRepository()
        {
            _beers = new List<Beer>
            {
                new Beer(1, "IPA", 6.5),
                new Beer(2, "Stout", 7.0),
                new Beer(3, "Pilsner", 4.5),
                new Beer(4, "Pale Ale", 5.2),
                new Beer(5, "Wheat Beer", 5.0)
            };
        }
        public List<Beer> Get(double? minAbv = null, double? maxAbv = null, string? sortBy = null)
        {
            var filteredBeers = _beers;

            if (minAbv.HasValue)
            {
                filteredBeers = filteredBeers.Where(b => b.Abv >= minAbv).ToList();
            }

            if (maxAbv.HasValue)
            {
                filteredBeers = filteredBeers.Where(b => b.Abv <= maxAbv).ToList();
            }

            if (!string.IsNullOrEmpty(sortBy))
            {
                if (sortBy.ToLower() == "name")
                {
                    filteredBeers = filteredBeers.OrderBy(b => b.Name).ToList();
                }
                else if (sortBy.ToLower() == "abv")
                {
                    filteredBeers = filteredBeers.OrderBy(b => b.Abv).ToList();
                }
            }
            return new List<Beer>(filteredBeers);
        }
        public Beer? GetById(int id)
        {
            return _beers.FirstOrDefault(b => b.Id == id);
        }

        public Beer? Add(Beer beer)
        {
            beer.Id = _beers.Count + 1;
            _beers.Add(beer);
            return beer;
        }

        public Beer? Delete(int id)
        {
            var beerToRemove = _beers.FirstOrDefault(b => b.Id == id);
            if (beerToRemove != null)
            {
                _beers.Remove(beerToRemove);
            }
            return beerToRemove;
        }

        public Beer? Update(int id, Beer values)
        {
            var beerToUpdate = _beers.FirstOrDefault(b => b.Id == id);
            if (beerToUpdate != null)
            {
                beerToUpdate.Name = values.Name;
                beerToUpdate.Abv = values.Abv;
                return beerToUpdate;
            }
            return null;
        }
    }
    
}
