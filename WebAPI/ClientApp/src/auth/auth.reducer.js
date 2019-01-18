import { SET_AUTHENTIFIED_STATE } from './auth.constants'

const initialState = {
  authentified: false,
  token: ''
}

export default (state = initialState, action = {}) => {
  switch (action.type) {
    case SET_AUTHENTIFIED_STATE:
      return {
        ...state,
        authentified: action.payload.authentified,
        token: action.payload.token
      }
    default:
      return state
  }
}
