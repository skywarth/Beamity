﻿using AutoMapper;
using Beamity.Application.DTOs;
using Beamity.Application.DTOs.BeaconDTOs;
using Beamity.Application.DTOs.ContentDTOs;
using Beamity.Application.DTOs.RelationDTO;
using Beamity.Application.Service.IServices;
using Beamity.Core.Models;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beamity.Application.Service.Services
{
    public class RelationService : IRelationService
    {
        private readonly RelationRepository _relationRepository;
        private readonly BeaconRepository _beaconRepository;
        private readonly ArtifactRepository _artifactRepository;
        private readonly ContentRepository _contentRepository;

        private readonly IMapper _mapper;

        public RelationService(RelationRepository relationRepository,
                                BeaconRepository beaconRepository,
                                ArtifactRepository artifactRepository,
                                ContentRepository contentRepository, IMapper mapper)
        {
            _relationRepository = relationRepository;
            _beaconRepository = beaconRepository;
            _artifactRepository = artifactRepository;
            _contentRepository = contentRepository;
            _mapper = mapper;
        }

        public void CreateRelation(CreateRelationDTO input)
        {
            Relation relation = new Relation()
            {
                Artifact = _artifactRepository.GetById(input.ArtifactId),
                Content = _contentRepository.GetById(input.ContentId),
                Beacon = _beaconRepository.GetById(input.BeaconId),
                Proximity = (Proximity)Enum.Parse(typeof(Proximity), input.Proximity, true)
            };
        }

        public void DeleteRelationDTO(DeleteRelationDTO input)
        {
            _relationRepository.Delete(input.Id);
        }

        public List<ReadRelationDTO> GetAllRelations()
        {
            List<Relation> relations = _relationRepository.GetAll();
            List<ReadRelationDTO> result = new List<ReadRelationDTO>();
            foreach (Relation item in relations)
            {
                ReadRelationDTO r = new ReadRelationDTO();

                r.ArtifacName = item.Artifact.Name;
                r.BeaconName = item.Beacon.Name;
                r.ContentName = item.Content.Name;
                r.Proximity = item.Proximity.ToString();

                result.Add(r);
            }
            return result;
        }

        public ReadRelationDTO GetRelation(EntityDTO input)
        {
            Relation relation = _relationRepository.GetById(input.Id);

            ReadRelationDTO result = new ReadRelationDTO()
            {
                ArtifacName = relation.Artifact.Name,
                BeaconName = relation.Beacon.Name,
                ContentName = relation.Content.Name,
                Proximity = relation.Proximity.ToString()
            };
            return result;
        }

        public ReadContentDTO GetRelationWithBeacon(GetContentWithBeaconDTO input)
        {
            var beacon = _beaconRepository.GetBeaconWithIds(input.UUID, input.Major, input.Minor);
            var relation = _relationRepository.GetRelationWithBeaconId(beacon.Id);
            return _mapper.Map<ReadContentDTO>(relation.Content);
        }

        public void UpdateRelation(UpdateRelationDTO input)
        {
            Relation result = new Relation()
            {
                Id = input.Id,
                Artifact = _artifactRepository.GetById(input.ArtifactId),
                Beacon = _beaconRepository.GetById(input.BeaconId),
                Content = _contentRepository.GetById(input.ContentId),
                Proximity = (Proximity)Enum.Parse(typeof(Proximity), input.Proximity, true)
            };


            _relationRepository.Update(result);
        }
    }
}