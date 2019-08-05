import React, { Component } from "react"
import styled from "styled-components/native"

export default class Modal extends Component {
  constructor() {
    super()
    this.state = {
      Visible: false,
      Header: "Atenção",
      Body: "Realmente deseja realizar esta ação?"
    }
    this.Data = null
  }

  componentWillMount() {
    this.setState({
      Header: this.props.Header,
      Body: this.props.Body
    })

    const ModalControl = {
      open: data => {
        this.Data = data
        this.setState({ Visible: true })
      },
      close: () => {
        this.setState({ Visible: false })
      }
    }

    this.props.refe(ModalControl)
  }

  onConfirm() {
    this.props.onConfirm(this.Data)
    this.setState({ Visible: false })
  }

  render() {
    if (this.state.Visible)
      return (
        <Container>
          <HeaderModal>
            <TextModal>{this.state.Header}</TextModal>
          </HeaderModal>
          <BodyModal>
            <ContentModal>
              <TextContentModal>{this.state.Body}</TextContentModal>
            </ContentModal>
          </BodyModal>
          <FooterModal>
            <ButtonConfirmModal onPress={this.onConfirm.bind(this)}>
              <TextButton>Confirmar</TextButton>
            </ButtonConfirmModal>
            <ButtonCancelModal
              onPress={() => this.setState({ Visible: false })}>
              <TextButton>Cancelar</TextButton>
            </ButtonCancelModal>
          </FooterModal>
        </Container>
      )
    return <></>
  }
}

const Container = styled.View`
  background-color: #ccc;
  position: absolute;
  height: 300;
  width: 80%;
  left: 10%;
  top: 25%;
  justify-content: space-between;
`

const HeaderModal = styled.View`
  padding: 20px;
  border-bottom-color: #999999;
  border-bottom-width: 1;
`

const TextModal = styled.Text`
  color: black;
  font-size: 20;
  font-weight: bold;
`

const BodyModal = styled.View`
  padding: 20px;
`

const ContentModal = styled.View``

const FooterModal = styled.View`
  flex-direction: row-reverse;
  justify-content: flex-start;
  padding: 20px;
  border-top-color: #999999;
  border-top-width: 1;
`
const TextContentModal = styled.Text`
  font-size: 17px;
`

const Button = styled.TouchableOpacity`
  width: 105px;
  height: 45px;
  padding: 12px;
  border-radius: 10px;
  background-color: rgb(0, 255, 0);
`

const ButtonCancelModal = styled(Button)`
  background-color: red;
  margin-right: 10px;
`
const ButtonConfirmModal = styled(Button)`
  background-color: green;
`

const TextButton = styled.Text`
  color: #fff;
  font-size: 14px;
  font-weight: bold;
  text-transform: uppercase;
  text-align: center;
`
