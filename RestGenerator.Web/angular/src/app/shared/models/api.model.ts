import { Resource } from '.';

export class Api {
    id: string;
    name: string;
    encryptionKey: string;
    decryptionKey: string;
    resources: Resource[] = [];
}
