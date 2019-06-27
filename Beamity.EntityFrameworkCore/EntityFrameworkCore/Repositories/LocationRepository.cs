﻿using Beamity.Core.Models;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories
{
    public class LocationRepository : BaseRepository<Location>
    {
        public LocationRepository(BeamityDbContext context)
            : base(context)
        {
        }
    }
}
