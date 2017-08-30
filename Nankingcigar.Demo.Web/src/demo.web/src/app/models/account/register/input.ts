/*
 * @Author: Chao Yang
 * @Date: 2017-08-25 14:06:35
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-08-28 07:11:01
 */
export class RegisterInput {
    constructor(
        public userName: string,
        public password: string,
        public displayName?: string
    ) {
    }
}
