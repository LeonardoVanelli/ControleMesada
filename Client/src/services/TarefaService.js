import Tarefa from "../models/Tarefa"
import HttpService from "./HttpService"

export default class AtividadeService {
  constructor() {
    this._httpService = new HttpService()
  }

  BuscaTodos() {
    return this._httpService
      .get("TarefasRest/GetAll")
      .then(tarefas => {
        return tarefas.map(tarefa => this._montaTarefa(tarefa))
      })
      .catch(err => {
        console.log(err)
      })
  }

  _montaTarefa(objTarefa) {
    return new Tarefa(
      objTarefa.Id,
      objTarefa.Nome,
      objTarefa.Descricao,
      objTarefa.Ativo
    )
  }
}
