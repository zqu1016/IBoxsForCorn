using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IBoxs.Sdk.Cqp.Model
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct GroupDataList
    {
        public int count;
        public GroupInfo pgroupInfo;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct GroupInfo
    {
        // 群ID
        public long GroupID;
        // 群号
        public long GroupQQ;
        // cFlag
        public long CFlag;
        // dwGroupInfoSeq
        public long GroupInfoSeq;
        // dwGroupFlagExt
        public long GroupFlagExt;
        // dwGroupRankSeq
        public long GroupRankSeq;
        // dwCertificationType
        public long CertificationType;
        // 禁言时间戳
        public long ShutUpTimestamp;
        // 框架QQ禁言时间戳
        public long ThisShutUpTimestamp;
        // dwCmdUinUinFlag
        public long CmdUinUinFlag;
        // dwAdditionalFlag
        public long AdditionalFlag;
        // dwGroupTypeFlag
        public long GroupTypeFlag;
        // dwGroupSecType
        public long GroupSecType;
        // dwGroupSecTypeInfo
        public long GroupSecTypeInfo;
        // dwGroupClassExt
        public long GroupClassExt;
        // dwAppPrivilegeFlag
        public long AppPrivilegeFlag;
        // dwSubscriptionUin
        public long SubscriptionUin;
        // 群成员数量
        public long GroupMemberCount;
        // dwMemberNumSeq
        public long MemberNumSeq;
        // dwMemberCardSeq
        public long MemberCardSeq;
        // dwGroupFlagExt3
        public long GroupFlagExt3;
        // dwGroupOwnerUin
        public long GroupOwnerUin;
        // cIsConfGroup
        public long IsConfGroup;
        // cIsModifyConfGroupFace
        public long IsModifyConfGroupFace;
        // cIsModifyConfGroupName
        public long IsModifyConfGroupName;
        // dwCmduinJoinTime
        public long CmduinJoinTime;
        // 群名称
        public IntPtr GroupName;
        // strGroupMemo
        public IntPtr GroupMemo;
    }
}

