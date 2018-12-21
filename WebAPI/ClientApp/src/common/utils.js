export const promiseDispatch = (action, payload) =>
  new Promise((resolve, reject) => action(payload, resolve, reject))
