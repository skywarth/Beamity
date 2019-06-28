﻿using Beamity.Application.DTOs.BeaconDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beamity.Application.Service.IServices
{
    public interface IBeaconService
    {
        void CreateBeacon(CreateBeaconDTO input);
        Task UpdateBeacon(UpdateBeaconDTO input);
        void DeleteBeacon(DeleteBeaconDTO input);
        List<ReadBeaconDTO> GetAllBeacons();
        ReadBeaconDTO GetBeacon(EnityDTO input);
    }
}
