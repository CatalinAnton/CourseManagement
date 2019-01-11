import { SET_RESOURCES } from './resources.constants'

const initialState = {
  resources: {}
}

export default (state = initialState, action = {}) => {
  switch (action.type) {
    case SET_RESOURCES:
      return {
        ...state,
        resources: {
          ...state.resources,
          [action.payload.courseId]: action.payload.resources
        }
      }
    default:
      return state
  }
}
