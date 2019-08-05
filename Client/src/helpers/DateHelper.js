export default class DateHelper {
  constructor() {
    throw new Error("This class can not be implemented")
  }

  static dateToExtensiveString(date) {
    const week = [
      "Domingo",
      "Segunda-Feira",
      "Terça-Feira",
      "Quarta-Feira",
      "Quinta-Feira",
      "Sexta-Feira",
      "Sabado"
    ]
    const month = [
      "Janeiro",
      "Fevereiro",
      "Março",
      "Abril",
      "Maio",
      "Junho",
      "Julho",
      "Agosto",
      "Setembro ",
      "Outubro",
      "Novembro",
      "Dezembro"
    ]

    return `${week[date.getDay()]}, ${date.getDate()} de ${
      month[date.getMonth()]
    } de ${date.getFullYear()}`
  }
}
