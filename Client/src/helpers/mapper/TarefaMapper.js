import Tarefa from '../../models/Tarefa'

export default class TarefaMapper{

    static objToModel(obj) {
        
        return new Tarefa(obj.Id,
            obj.Nome,
            obj.Descricao,
            obj.Ativo)
    }
}