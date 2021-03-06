﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RevStackCore.Pattern.Graph
{
    public interface IGraphService<TEntity,TKey> : IService<TEntity,TKey> where TEntity : class, IEntity<TKey>
    {
        //sync
        IEnumerable<TEntity> Get(int limit, int skip);
        IEnumerable<TEntity> Get(string label);
        IEnumerable<TEntity> Get(string label, int limit, int skip);
        IEnumerable<string> GetLabels(TKey id);
        bool AddLabel(TKey id, string label);
        bool DeleteLabel(TKey id, string label);
        IEnumerable<TOut> GetRelated<TOut>(TKey id, string relationship) where TOut : class, IEntity<TKey>;
        IEnumerable<TOut> GetRelated<TOut, TRelation>(TKey id, string relationship, Expression<Func<TRelation, bool>> predicate) where TOut : class, IEntity<TKey> where TRelation : class;
        int GetRelatedCount<TOut>(TKey id, string relationship) where TOut : class, IEntity<TKey>;
        int GetRelatedCount<TOut, TRelation>(TKey id, string relationship, Expression<Func<TRelation, bool>> predicate) where TOut : class, IEntity<TKey> where TRelation : class;
        bool AddRelationShip<TOut>(TKey inboundId, TKey outboundId, string relationship) where TOut : class, IEntity<TKey>;
        bool AddRelationShip<TOut, TRelation>(TKey inboundId, TKey outboundId, string relationship, TRelation relation) where TOut : class, IEntity<TKey> where TRelation : class;
        bool HasRelationship<TOut>(TKey inboundId, TKey outboundId, string relationship) where TOut : class, IEntity<TKey>;
        bool DeleteRelationShip<TOut>(TKey inboundId, TKey outboundId, string relationship) where TOut : class, IEntity<TKey>;
        bool CreateConstraint();
        bool CreateIndex();
        bool CreateIndex(string property);
        IQueryable<TEntity> Find(string label, Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> Find(string label, string expression);
        IQueryable<TEntity> Find(string expression);
        IQueryable<TEntity> Find(string label, Expression<Func<TEntity, bool>> predicate, int limit, int skip);
        IQueryable<TEntity> Find(string label, string expression, int limit, int skip);
        IQueryable<TEntity> Find(string expression, int limit, int skip);
        //async
        Task<IEnumerable<TEntity>> GetAsync(int limit, int skip);
        Task<IEnumerable<TEntity>> GetAsync(string label);
        Task<IEnumerable<TEntity>> GetAsync(string label, int limit, int skip);
        Task<IEnumerable<string>> GetLabelsAsync(TKey id);
        Task<bool> AddLabelAsync(TKey id, string label);
        Task<bool> DeleteLabelAsync(TKey id, string label);
        Task<IEnumerable<TOut>> GetRelatedAsync<TOut>(TKey id, string relationship) where TOut : class, IEntity<TKey>;
        Task<IEnumerable<TOut>> GetRelatedAsync<TOut, TRelation>(TKey id, string relationship, Expression<Func<TRelation, bool>> predicate) where TOut : class, IEntity<TKey> where TRelation : class;
        Task<int> GetRelatedCountAsync<TOut>(TKey id, string relationship) where TOut : class, IEntity<TKey>;
        Task<int> GetRelatedCountAsync<TOut, TRelation>(TKey id, string relationship, Expression<Func<TRelation, bool>> predicate) where TOut : class, IEntity<TKey> where TRelation : class;
        Task<bool> AddRelationShipAsync<T>(TKey inboundId, TKey outboundId, string relationship) where T : class, IEntity<TKey>;
        Task<bool> AddRelationShipAsync<TOut, TRelation>(TKey inboundId, TKey outboundId, string relationship, TRelation relation) where TOut : class, IEntity<TKey> where TRelation : class;
        Task<bool> HasRelationshipAsync<TOut>(TKey inboundId, TKey outboundId, string relationship) where TOut : class, IEntity<TKey>;
        Task<bool> DeleteRelationShipAsync<TOut>(TKey inboundId, TKey outboundId, string relationship) where TOut : class, IEntity<TKey>;
        Task<bool> CreateConstraintAsync();
        Task<bool> CreateIndexAsync();
        Task<bool> CreateIndexAsync(string property);
        Task<IQueryable<TEntity>> FindAsync(string label, Expression<Func<TEntity, bool>> predicate);
        Task<IQueryable<TEntity>> FindAsync(string label, string expression);
        Task<IQueryable<TEntity>> FindAsync(string expression);
        Task<IQueryable<TEntity>> FindAsync(string label, Expression<Func<TEntity, bool>> predicate, int limit, int skip);
        Task<IQueryable<TEntity>> FindAsync(string label, string expression, int limit, int skip);
        Task<IQueryable<TEntity>> FindAsync(string expression, int limit, int skip);
    }
}
