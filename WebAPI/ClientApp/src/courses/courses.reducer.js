import { SET_COURSES } from './courses.constants'

const initialState = {
  courses: []
}

export default (state = initialState, action = {}) => {
  switch (action.type) {
    case SET_COURSES:
      return {
        ...state,
        courses: action.payload.courses
      }
    default:
      return state
  }
}
