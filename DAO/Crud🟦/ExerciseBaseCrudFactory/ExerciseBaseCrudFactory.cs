using DTOs;
using DAO.Mapper;
using System;
using System.Collections.Generic;

namespace DAO.Crud
{
    public class ExerciseBaseCrudFactory : CrudFactory
    {
        private readonly ExerciseBaseMapper _mapper;

        public ExerciseBaseCrudFactory()
        {
            _mapper = new ExerciseBaseMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var exerciseBase = (ExerciseBaseDTO)entity;
            var sqlOperation = _mapper.GetCreateStatement(exerciseBase);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Update(BaseEntity entity)
        {
            var exerciseBase = (ExerciseBaseDTO)entity;
            var sqlOperation = _mapper.GetUpdateStatement(exerciseBase);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entity)
        {
            var exerciseBase = (ExerciseBaseDTO)entity;
            var sqlOperation = _mapper.GetDeleteStatement(exerciseBase.Id);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrieve<T>(int id)
        {
            var sqlOperation = _mapper.GetRetrieveByIdStatement(id);
            var lstResult = dao.ExecuteQueryProcedure(sqlOperation);
            var dic = new Dictionary<string, object>();

            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
            }

            var exerciseBase = _mapper.BuildObject(dic);
            return (T)Convert.ChangeType(exerciseBase, typeof(T));
        }

        public override List<T> RetrieveAll<T>()
        {
            var sqlOperation = _mapper.GetRetrieveAllStatement();
            var lstResult = dao.ExecuteQueryProcedure(sqlOperation);

            var exerciseBases = _mapper.BuildObjects(lstResult);
            var list = new List<T>();

            foreach (var exerciseBase in exerciseBases)
            {
                list.Add((T)Convert.ChangeType(exerciseBase, typeof(T)));
            }

            return list;
        }
    }
}
