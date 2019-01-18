import { SEARCH } from './search.constants'

export const search = ({ term }, resolve, reject) => ({
  type: SEARCH,
  payload: { term, resolve, reject }
})
