using DTOs;
using DAO.Crud;
using System.Collections.Generic;
using DTO.TypeExcercise;
namespace Managers
{

    public class TypeExerciseManager: CrudFactory<TypeExerciseDTO>
    {
        private readonly TypeExerciseCrudFactory _TypeExerciseCrudFactory;
        
            public TypeExerciseManager()
            {
                _TypeExerciseCrudFactory = new TypeExerciseCrudFactory();
            }

            public override TypeExerciseDTO Create(TypeExerciseDTO entityDTO)
            {
                return _TypeExerciseCrudFactory.Create(entityDTO);
            }

            public override TypeExerciseDTO Update(TypeExerciseDTO entityDTO)
            {
                return _TypeExerciseCrudFactory.Update(entityDTO);
            }

            public override List<TypeExerciseDTO> RetrieveAll()
            {
                return _TypeExerciseCrudFactory.RetrieveAll();
            }

            public override TypeExerciseDTO RetrieveById(int id)
            {
                return _TypeExerciseCrudFactory.RetrieveById(id);
            }

        public override TypeExerciseDTO Delete(TypeExerciseDTO entityDTO)
        {
            return _TypeExerciseCrudFactory.Delete(entityDTO);
        }
    }
    
}