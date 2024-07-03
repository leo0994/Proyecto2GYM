using DTOs;
using DAO.Crud;
using DAO.Mapper;

namespace DAO.Crud
{
    public class ExerciseCrudFactory : CrudFactory
    {
        private readonly ExerciseMapper _mapper;

        public ExerciseCrudFactory()
        {
            _mapper = new ExerciseMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var exercise = (ExerciseDTO)entity;
            var sqlOperation = _mapper.GetCreateStatement(exercise);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Update(BaseEntity entity)
        {
            var exercise = (ExerciseDTO)entity;
            var sqlOperation = _mapper.GetUpdateStatement(exercise);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entity)
        {
            var exercise = (ExerciseDTO)entity;
            var sqlOperation = _mapper.GetDeleteStatement(exercise.Id);
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

            var exercise = _mapper.BuildObject(dic);
            return (T)Convert.ChangeType(exercise, typeof(T));
        }

        public override List<T> RetrieveAll<T>()
        {
            var sqlOperation = _mapper.GetRetrieveAllStatement();
            var lstResult = dao.ExecuteQueryProcedure(sqlOperation);

            var exercises = _mapper.BuildObjects(lstResult);
            var list = new List<T>();

            foreach (var exercise in exercises)
            {
                list.Add((T)Convert.ChangeType(exercise, typeof(T)));
            }

            return list;
        }
    }
}
