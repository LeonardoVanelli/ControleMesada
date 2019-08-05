export default class Atividade {
  constructor(Id, DataRealizada, Pessoa, Tarefa) {
    this.Id = Id
    this.DataRealizada = this._GetDateByDateIsObjectOrString(DataRealizada)
    this.Pessoa = Pessoa
    this.Tarefa = Tarefa
  }

  _GetDateByDateIsObjectOrString(DataRealizada) {
    if (typeof DataRealizada == "object") return new Date(DataRealizada)
    return new Date(parseInt(DataRealizada.slice(6, DataRealizada.length - 2)))
  }
}
