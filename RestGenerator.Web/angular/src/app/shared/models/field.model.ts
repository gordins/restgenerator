import { FieldType } from './enums';

export class Field {
  id: string;
  resourceId: string;
  type: FieldType;
  isRequired: boolean;
  isUnique: boolean;
  isEncrypted: boolean;
}
