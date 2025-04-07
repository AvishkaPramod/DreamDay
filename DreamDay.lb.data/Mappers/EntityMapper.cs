﻿using AutoMapper;
using DreamDay.lb.dbcontext.tables.Models;
using DreamDay.lb.entities.User;
using DreamDay.lb.shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamDay.lb.data.Mappers
{
    /// <summary>
    /// EntityMapper
    /// </summary>
    /// <seealso cref="DreamDay.lb.shared.Contracts.IEntityMapper" />
    public class EntityMapper: IEntityMapper
    {
        /// <summary>
        /// The configuration
        /// </summary>
        private MapperConfiguration _config;

        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper _mapper;


        /// <summary>
        /// Initializes a new instance of the <see cref="EntityMapper"/> class.
        /// </summary>
        public EntityMapper()
        {
            Configure();
            Create();
        }
        /// <summary>
        /// Configures this instance.
        /// </summary>
        /// 

        private void Configure()
        {
            _config = new MapperConfiguration(cfg =>
            {
                // User
                cfg.CreateMap<user, UserSaveRequest>().ReverseMap();
                cfg.CreateMap<user, UserResponse>().ReverseMap();

            });
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// 

        private void Create()
        {
            _mapper = _config.CreateMapper();
        }
        /// <summary>
        /// Maps the specified source.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TDestination">The type of the destination.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return _mapper.Map<TSource, TDestination>(source);
        }
    }


}
