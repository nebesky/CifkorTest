using System;
using System.Collections.Generic;

namespace Engine.Network.Responses
{
    //for deserialization
    [Serializable]
    public struct DogsApiResponse
    {
        public List<DogBreed> Data;
        public MetaData Meta;
        public LinksData Links;
    }

    [Serializable]
    public struct DogBreed
    {
        public string Id;
        public string Type;
        public DogAttributes Attributes;
        public DogRelationships Relationships;
    }

    [Serializable]
    public struct DogAttributes
    {
        public string Name;
        public string Description;
        public LifeSpan Life;
        public Weight MaleWeight;
        public Weight FemaleWeight;
        public bool Hypoallergenic;
    }

    [Serializable]
    public struct LifeSpan
    {
        public int Min;
        public int Max;
    }

    [Serializable]
    public struct Weight
    {
        public int Min;
        public int Max;
    }
    
    [Serializable]
    public struct DogRelationships
    {
        public GroupData Group;
    }

    [Serializable]
    public struct GroupData
    {
        public GroupInfo Data;
    }
    
    [Serializable]
    public struct GroupInfo
    {
        public string Id;
        public string Type;
    }

    [Serializable]
    public struct MetaData
    {
        public PaginationData Pagination;
    }
    
    [Serializable]
    public struct PaginationData
    {
        public int Current;
        public int Next;
        public int Last;
        public int Records;
    }

    [Serializable]
    public struct LinksData
    {
        public string Self;
        public string Current;
        public string Next;
        public string Last;
    }
}