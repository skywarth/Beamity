﻿using Beamity.Application.DTOs;
using Beamity.Application.DTOs.BeaconDTOs;
using Beamity.Application.DTOs.ContentDTOs;
using Beamity.Application.DTOs.RelationDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beamity.Application.Service.IServices
{
    public interface IRelationService
    {
        List<ReadRelationDTO> GetAllRelations();
        ReadRelationDTO GetRealtion(EntityDTO input);
        //Beacon Id den relation ı , oradan da  contenti bulur ve döndürür
        ReadContentDTO GetRelationWithBeacon(GetContentWithBeaconDTO input);
        void CreateRelation(CreateRelationDTO input);
        void DeleteRelationDTO(DeleteRelationDTO input);
        Task UpdateRelation(UpdateRelationDTO input);
    }
}
