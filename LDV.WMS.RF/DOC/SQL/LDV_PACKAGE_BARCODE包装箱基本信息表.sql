prompt PL/SQL Developer import file
prompt Created on 2012��3��30�������� by Administrator
set feedback off
set define off
prompt Creating LDV_PACKAGE_BARCODE...
create table LDV_PACKAGE_BARCODE
(
  ID              INTEGER not null,
  PACKAGE_BARCODE VARCHAR2(20),
  CREATE_DATE     TIMESTAMP(6),
  CREATE_USER_ID  INTEGER
)
;
comment on column LDV_PACKAGE_BARCODE.PACKAGE_BARCODE
  is '��װ������';
comment on column LDV_PACKAGE_BARCODE.CREATE_DATE
  is '����ʱ��';
comment on column LDV_PACKAGE_BARCODE.CREATE_USER_ID
  is '������';
alter table LDV_PACKAGE_BARCODE
  add constraint LDV_PACKAGE_BARCODE_KEY primary key (ID);

prompt Disabling triggers for LDV_PACKAGE_BARCODE...
alter table LDV_PACKAGE_BARCODE disable all triggers;
prompt Deleting LDV_PACKAGE_BARCODE...
delete from LDV_PACKAGE_BARCODE;
commit;
prompt Loading LDV_PACKAGE_BARCODE...
prompt Table is empty
prompt Enabling triggers for LDV_PACKAGE_BARCODE...
alter table LDV_PACKAGE_BARCODE enable all triggers;
set feedback on
set define on
prompt Done.
