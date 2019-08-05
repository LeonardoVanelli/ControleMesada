export default class Atividade {
  constructor(DataRealizada, Nome, Valor) {
    this.DataRealizada = this._GetDateByDateIsObjectOrString(DataRealizada)
    this.Nome = Nome
    this.Valor = Valor
  }

  _GetDateByDateIsObjectOrString(DataRealizada) {
    if (typeof DataRealizada == "object") return new Date(DataRealizada)
    return new Date(parseInt(DataRealizada.slice(6, DataRealizada.length - 2)))
  }
}
