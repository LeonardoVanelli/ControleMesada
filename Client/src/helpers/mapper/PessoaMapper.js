import Pessoa from '../../models/Pessoa'

export default class PessoaMapper {

    static objToModel(obj) {
        
        return new Pessoa(obj.Id,
            obj.Nome,
            obj.Email,
            obj.Apelido)
    }
}