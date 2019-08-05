import AtividadeService from "../services/AtividadeService"
import TarefaService from "../services/TarefaService"
import CurrentUser from "../helpers/CurrentUser"
import Atividade from "../models/Atividade"

export default class AtividadeController {
  constructor() {
    this.AtividadeService = new AtividadeService()
    this.TarefaService = new TarefaService()
  }

  AtualizaListaTarefa() {
    return new Promise((res, rej) => {
      CurrentUser.get().then(pessoa => {
        this.AtividadeService.BuscaPorUsuarioId(pessoa.Id)
          .then(atividades => {
            res(atividades)
          })
          .catch(err => rej(err))
      })
    })
  }

  AdicionarAtividade(dataRealizada, tarefa) {
    return CurrentUser.get().then(pessoa => {
      let atividade = new Atividade(null, dataRealizada, pessoa, tarefa)
      return this.AtividadeService.Cadastra(atividade)
    })
  }

  BuscaTarefas() {
    return new Promise((res, rej) => {
      this.TarefaService.BuscaTodos()
        .then(tarefas => res(tarefas))
        .catch(err => rej(err))
    })
  }
}
