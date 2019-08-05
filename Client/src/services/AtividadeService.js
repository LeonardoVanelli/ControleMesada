import Atividade from "../models/Atividade"
import HttpService from "./HttpService"
import PessoaMapper from "../helpers/mapper/PessoaMapper"
import TarefaMapper from "../helpers/mapper/TarefaMapper"

export default class AtividadeService {
  constructor() {
    this._httpService = new HttpService()
  }

  BuscaTodos() {
    return this._httpService
      .get("AtividadesRest/getall")
      .then(objAtividades => {
        return objAtividades.map(objAtividade =>
          this._MontaAtividade(objAtividade)
        )
      })
  }

  BuscaPorUsuarioId(idUsuario) {
    return this._httpService
      .get("AtividadesRest/getByUser/" + idUsuario)
      .then(objAtividades => {
        return objAtividades.map(objAtividade =>
          this._MontaAtividade(objAtividade)
        )
      })
      .catch(err => {
        throw new Error(err)
      })
  }

  BuscaAtividadesDeHoje() {
    return this._httpService
      .get(`AtividadesRest/GetAllByDate?date=${new Date().toJSON()}`)
      .then(objAtividades => {
        return objAtividades.map(objAtividade =>
          this._MontaAtividade(objAtividade)
        )
      })
  }

  Cadastra(atividade) {
    return this._httpService
      .post("AtividadesRest/Create", atividade)
      .then(atividade => this._MontaAtividade(atividade))
  }

  _MontaAtividade(objAtividade) {
    return new Atividade(
      objAtividade.Id,
      objAtividade.DataRealizada,
      PessoaMapper.objToModel(objAtividade.Pessoa),
      TarefaMapper.objToModel(objAtividade.Tarefa)
    )
  }
}
