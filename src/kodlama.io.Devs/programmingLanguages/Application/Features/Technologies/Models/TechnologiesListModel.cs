﻿using Application.Features.Technologies.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Models
{
    public class TechnologiesListModel
    {
        public IList<TechnologiesListDto> Items { get; set; }
    }
}
