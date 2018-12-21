import { SET_AUTHENTIFIED_STATE } from './auth.constants'

const initialState = {
  authentified: false
}

export default (state = initialState, action = {}) => {
  switch (action.type) {
    case SET_AUTHENTIFIED_STATE:
      return {
        ...state,
        authentified: action.payload.authentified
      }
    default:
      return state
  }
}
