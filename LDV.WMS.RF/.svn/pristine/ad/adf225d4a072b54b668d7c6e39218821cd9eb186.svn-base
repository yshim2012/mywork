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
comment on table LDV_PLAN_CHECK  is  'LDV_PLAN_CHECK表';
 comment on column   LDV_PLAN_CHECK.id  is '';
 comment on column   LDV_PLAN_CHECK.CHECK_CREDENCE  is '盘点凭证';
 comment on column   LDV_PLAN_CHECK.PLAN_CHECK_DATE  is '计划盘点日期';
 comment on column   LDV_PLAN_CHECK.STATE  is '状态:OP新建，FI完成，CK盘点中，IV无效';
 comment on column   LDV_PLAN_CHECK.CREATE_DATE  is '创建时间';
 comment on column   LDV_PLAN_CHECK.CREATE_USER_ID  is '创建人';
 comment on column   LDV_PLAN_CHECK.LAST_MODIFY_DATE  is '最近修改时间';
 comment on column   LDV_PLAN_CHECK.LAST_MODIFY_USER_ID  is '最近修改人';
alter table LDV_PLAN_CHECK  add constraint LDV_PLAN_CHECK_ID_PK primary key (ID)   using index    tablespace LDVWMS   pctfree 10   initrans 2   maxtrans 255   storage   (     initial 64K     minextents 1     maxextents unlimited   );
