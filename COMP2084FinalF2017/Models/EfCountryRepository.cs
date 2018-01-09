﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COMP2084FinalF2017.Models
{
    public class EfCountryRepository : icountryRepository
    {
        private OlympicModel db = new OlympicModel();
        public IQueryable<Country> Countries { get { return db.Countries; } }

        public void Delete(Country country)
        {
            db.Countries.Remove(country);
            db.SaveChanges();

        }

        public Country Save(Country country)
        {
            if (country.CountryID==0)
            {
                db.Countries.Add(country);
            }
            else
            {
                db.Entry(country).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return country;
        }
    }
}