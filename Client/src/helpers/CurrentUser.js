import AsyncStorage from '@react-native-community/async-storage';
import PessoaMapper from './mapper/PessoaMapper'

export default class CurrentUser {
    
    static get() {
        
        return AsyncStorage.getItem('@UsuarioLogado')
            .then(strUser => {
                let pessoa = PessoaMapper.objToModel(JSON.parse(strUser))
                return pessoa
            })
            .catch(err => {
                console.log(err)
                rej('Não foi possivel obter o usuario logado')
            })      
    }
}