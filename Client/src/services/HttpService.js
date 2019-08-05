import ServerConfig from "../../config/server.json"

export default class HttpService {
  constructor() {
    this.url = ServerConfig.Connection.route
  }

  _handleErrors(res) {
    if (!res.ok) res
    return res
  }

  get(url) {
    return fetch(this.url + url)
      .then(res => this._handleErrors(res))
      .then(res => res.json())
  }

  post(url, dado) {
    return fetch(this.url + url, {
      headers: { "Content-type": "application/json" },
      method: "POST",
      body: JSON.stringify(dado)
    })
      .then(res => this._handleErrors(res))
      .then(res => res.json())
  }
}
