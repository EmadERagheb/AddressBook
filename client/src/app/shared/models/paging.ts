export interface Paging<T> {
    pageIndex: number;
    pageSize: number;
    count: number;
    data: T;
}
