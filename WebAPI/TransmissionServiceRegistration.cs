﻿using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Concrete;
using Business.Requests.Transmission;
using Business.Responses.Fuel;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace WebAPI;

public static class TransmissionServiceRegistration
{
    public static readonly ITransmissionDal TransmissionDal = new InMemoryTransmissionDal();

    public static readonly TransmissionBusinessRules TransmissionBusinessRules = new TransmissionBusinessRules(TransmissionDal);

    public static IMapper Mapper = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<AddTransmissionRequest, Transmission>();
        cfg.CreateMap<Transmission, AddTransmissionResponse>();
    }).CreateMapper();

    public static readonly ITransmissionService TransmissionService = new TransmissionManager(
        TransmissionDal,
        TransmissionBusinessRules,
        Mapper
    );
}
