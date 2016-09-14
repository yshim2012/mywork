create table LDV_PLAN_CHECK(
ID                       NUMBER(20) not null,
CHECK_CREDENCE          VARCHAR(20),
PLAN_CHECK_DATE          TIMESTAMP(6),
STATE          VARCHAR(2),
CREATE_DATE          TIMESTAMP(6),
CREATE_USER_ID          INTEGER,
LAST_MODIFY_DATE          TIMESTAMP(6),
LAST_MODIFY_USER_ID          INTEGER
)tablespace LDVWMS pctfree 10 initrans 1 maxtrans 255 storage(    initial 64K minextents 1 maxextents unlimited);
comment on table LDV_PLAN_CHECK  is  'LDV_PLAN_CHECK��';
 comment on column   LDV_PLAN_CHECK.id  is '';
 comment on column   LDV_PLAN_CHECK.CHECK_CREDENCE  is '�̵�ƾ֤';
 comment on column   LDV_PLAN_CHECK.PLAN_CHECK_DATE  is '�ƻ��̵�����';
 comment on column   LDV_PLAN_CHECK.STATE  is '״̬:OP�½���FI��ɣ�CK�̵��У�IV��Ч';
 comment on column   LDV_PLAN_CHECK.CREATE_DATE  is '����ʱ��';
 comment on column   LDV_PLAN_CHECK.CREATE_USER_ID  is '������';
 comment on column   LDV_PLAN_CHECK.LAST_MODIFY_DATE  is '����޸�ʱ��';
 comment on column   LDV_PLAN_CHECK.LAST_MODIFY_USER_ID  is '����޸���';
alter table LDV_PLAN_CHECK  add constraint LDV_PLAN_CHECK_ID_PK primary key (ID)   using index    tablespace LDVWMS   pctfree 10   initrans 2   maxtrans 255   storage   (     initial 64K     minextents 1     maxextents unlimited   );
