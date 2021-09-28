using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logixboard.API.DTOs;
using Logixboard.API.Repositories;
using Logixboard.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Logixboard.API.Extensions
{
    public static class UnitConverters
    {
        const decimal ouncePound = 16;
        const decimal ounceKilogram = 35.274m;
        const decimal poundKilogram = 2.205m;
        public static decimal Convert(decimal value, Unit from, Unit to){
            if(from == Unit.OUNCES && to == Unit.POUNDS){
                return value / ouncePound;
            }
            else if(from == Unit.OUNCES && to == Unit.KILOGRAMS) {
                return value / ounceKilogram;
            }
            else if(from == Unit.POUNDS && to == Unit.OUNCES) {
                return value * ouncePound;
            }
            else if(from == Unit.POUNDS && to == Unit.KILOGRAMS) {
                return value / poundKilogram;
            }
            else if(from == Unit.KILOGRAMS && to == Unit.OUNCES) {
                return value * ounceKilogram;
            }
            else if(from == Unit.KILOGRAMS && to == Unit.POUNDS) {
                return value * poundKilogram;
            }
            else {
                return value;
            }
        }
    }
}