/** 静态数据库 */
export class DBManager {
    private static dbMap: Map<number | string, Map<string, any>> = new Map();

    // 获取数据库
    public static getDB(key: string): Map<number | string, any> | undefined {
        return this.dbMap[key];
    }

    // 获取数据库
    public static getDb(key: string): Map<number | string, any> | undefined {
        return this.dbMap[key];
    }

// ==================== 数据库GET方法 ====================

    public static getDBDungeon(id: number): DBDungeon | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBDungeon");
    return db ? db.get(id) : undefined;
    }

    public static getDBFund(id: number): DBFund | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBFund");
    return db ? db.get(id) : undefined;
    }

    public static getDBSevenCheckIn(id: number): DBSevenCheckIn | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBSevenCheckIn");
    return db ? db.get(id) : undefined;
    }

    public static getDBMission(id: number): DBMission | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBMission");
    return db ? db.get(id) : undefined;
    }

    public static getDBDailyMission(id: number): DBDailyMission | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBDailyMission");
    return db ? db.get(id) : undefined;
    }

    public static getDBWeeklyMission(id: number): DBWeeklyMission | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBWeeklyMission");
    return db ? db.get(id) : undefined;
    }

    public static getDBAchievementMission(id: number): DBAchievementMission | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBAchievementMission");
    return db ? db.get(id) : undefined;
    }

    public static getDBDailyMissionProgress(progress: number): DBDailyMissionProgress | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBDailyMissionProgress");
    return db ? db.get(progress) : undefined;
    }

    public static getDBWeeklyMissionProgress(progress: number): DBWeeklyMissionProgress | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBWeeklyMissionProgress");
    return db ? db.get(progress) : undefined;
    }

    public static getDBCurrencyShop(id: number): DBCurrencyShop | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBCurrencyShop");
    return db ? db.get(id) : undefined;
    }

    public static getDBMiniGame(id: number): DBMiniGame | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBMiniGame");
    return db ? db.get(id) : undefined;
    }

    public static getDBChapter(id: number): DBChapter | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBChapter");
    return db ? db.get(id) : undefined;
    }

    public static getDBMaze(id: number): DBMaze | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBMaze");
    return db ? db.get(id) : undefined;
    }

    public static getDBSummon(id: number): DBSummon | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBSummon");
    return db ? db.get(id) : undefined;
    }

    public static getDBSummonInfo(lv: number): DBSummonInfo | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBSummonInfo");
    return db ? db.get(lv) : undefined;
    }

    public static getDBUnlockFunc(id: number): DBUnlockFunc | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBUnlockFunc");
    return db ? db.get(id) : undefined;
    }

    public static getDbConstNumber(key: string): DbConstNumber | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DbConstNumber");
    return db ? db.get(key) : undefined;
    }

    public static getDbConstArray(key: string): DbConstArray | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DbConstArray");
    return db ? db.get(key) : undefined;
    }

    public static getDbConstRes(key: string): DbConstRes | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DbConstRes");
    return db ? db.get(key) : undefined;
    }

    public static getDbChannel(id: number): DbChannel | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DbChannel");
    return db ? db.get(id) : undefined;
    }

    public static getDBEnemyTeam(id: number): DBEnemyTeam | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBEnemyTeam");
    return db ? db.get(id) : undefined;
    }

    public static getDB_Buff(id: number): DB_Buff | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DB_Buff");
    return db ? db.get(id) : undefined;
    }

    public static getDB_Rank0(id: number): DB_Rank0 | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DB_Rank0");
    return db ? db.get(id) : undefined;
    }

    public static getDB_Rank1(id: number): DB_Rank1 | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DB_Rank1");
    return db ? db.get(id) : undefined;
    }

    public static getDB_Rank2(id: number): DB_Rank2 | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DB_Rank2");
    return db ? db.get(id) : undefined;
    }

    public static getDB_Rank3(id: number): DB_Rank3 | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DB_Rank3");
    return db ? db.get(id) : undefined;
    }

    public static getSheet4(id: number): Sheet4 | undefined {
    const db: Map<number | string, any> = this.dbMap.get("Sheet4");
    return db ? db.get(id) : undefined;
    }

    public static getdict_main(key: string): dict_main | undefined {
    const db: Map<number | string, any> = this.dbMap.get("dict_main");
    return db ? db.get(key) : undefined;
    }

    public static getdict_icon(key: string): dict_icon | undefined {
    const db: Map<number | string, any> = this.dbMap.get("dict_icon");
    return db ? db.get(key) : undefined;
    }

    public static getBuffData(id: number): BuffData | undefined {
    const db: Map<number | string, any> = this.dbMap.get("BuffData");
    return db ? db.get(id) : undefined;
    }

    public static getPuzzleItemData(id: number): PuzzleItemData | undefined {
    const db: Map<number | string, any> = this.dbMap.get("PuzzleItemData");
    return db ? db.get(id) : undefined;
    }

    public static getEnemyModuleData(id: number): EnemyModuleData | undefined {
    const db: Map<number | string, any> = this.dbMap.get("EnemyModuleData");
    return db ? db.get(id) : undefined;
    }

    public static getDbPay(id: number): DbPay | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DbPay");
    return db ? db.get(id) : undefined;
    }

    public static getDbPrice(id: number): DbPrice | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DbPrice");
    return db ? db.get(id) : undefined;
    }

    public static getDBHeroProperty(key: number): DBHeroProperty | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBHeroProperty");
    return db ? db.get(key) : undefined;
    }

    public static getDBTeamProperty(key: number): DBTeamProperty | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBTeamProperty");
    return db ? db.get(key) : undefined;
    }

    public static getSkillData(id: number): SkillData | undefined {
    const db: Map<number | string, any> = this.dbMap.get("SkillData");
    return db ? db.get(id) : undefined;
    }

    public static getSummonData(id: number): SummonData | undefined {
    const db: Map<number | string, any> = this.dbMap.get("SummonData");
    return db ? db.get(id) : undefined;
    }

    public static getBulletData(id: number): BulletData | undefined {
    const db: Map<number | string, any> = this.dbMap.get("BulletData");
    return db ? db.get(id) : undefined;
    }

    public static getDbBattleAbility(id: number): DbBattleAbility | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DbBattleAbility");
    return db ? db.get(id) : undefined;
    }

    public static getDropData(id: number): DropData | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DropData");
    return db ? db.get(id) : undefined;
    }

    public static getDBHeroData(id: number): DBHeroData | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBHeroData");
    return db ? db.get(id) : undefined;
    }

    public static getDBSummoner(name: string): DBSummoner | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBSummoner");
    return db ? db.get(name) : undefined;
    }

    public static getDBHeroUpgrade(id: number): DBHeroUpgrade | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBHeroUpgrade");
    return db ? db.get(id) : undefined;
    }

    public static getDBCurrencyData(id: number): DBCurrencyData | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBCurrencyData");
    return db ? db.get(id) : undefined;
    }

    public static getDBDailyCurrencyData(id: number): DBDailyCurrencyData | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBDailyCurrencyData");
    return db ? db.get(id) : undefined;
    }

    /** 初始化数据库 */
    private static _initDatabase(_json: any, jsonKey: string): boolean {
        interface IExportDB {
            //数据库KEY
            sheetKeys: string[],
            //数据库数据
            sheetData: object[],
        }

        const db: IExportDB = _json[jsonKey];
        if (!db) {
            console.error('db is null ! ', jsonKey);
            return false;
        }

        const dbData: Record<number | string, any> = {};
        for (const data of db.sheetData) {
            let keys: string[] = [];
            Object.entries(data).forEach(([key, value]: [string, any]) => {
                if (db.sheetKeys.includes(key)) keys.push(value);
            });
            dbData[keys.join("_")] = data;
        }
        this.dbRecord[jsonKey] = dbData;
        return true;
    }

    /** 初始化数据库 */
    public static initDbWithIgnore(_json: any): boolean {
        const arrJsonKeys: string[] = Object.keys(_json);
        for (const jsonKey of arrJsonKeys) {
            if (!DBManager._initDatabase(_json, jsonKey)) {
                return false;
            }
        }
        return true;
    }
}

// ==================== 自定义接口 ====================

export interface IAdConfig {
    // 
    id: string
    // 
    width: number
    // 
    height: number
    // 
    originX: number
    // 
    originY: number
    // 
    anchorX: number
    // 
    anchorY: number
    // 
    offsetX: number
    // 
    offsetY: number
    // 
    interval: number
}

export interface IStyle {
    // 
    width: number
    // 
    height: number
    // 
    originX: number
    // 
    originY: number
    // 
    anchorX: number
    // 
    anchorY: number
    // 
    offsetX: number
    // 
    offsetY: number
}

export interface IRecord {
    // 
    title: string
    // 
    topic: Array<string>
}

export interface IProperty {
    // 
    type: number
    // 
    id: number
    // 
    value: number
}

export interface IRes {
    // 
    type: number
    // 
    id: number
    // 
    count: number
}

export interface HeroProperty {
    // 
    property: IProperty
    // 
    formal: number
    // 
    value: number
}

export interface IChapterChest {
    // 
    rank: number
    // 
    res: Array<IRes>
}

// ==================== 数据表接口 ====================

export interface DBDungeon {
    // id
    id: number;
    // 图标名称
    iconName: string;
    // 名称
    name: string;
    // 底板
    baseboard: string;
    // 详情底板
    detailBaseboard: string;
    // 消耗货币ID
    costId: number;
    // 广告货币ID
    adId: number;
    // 功能解锁ID
    funcId: number;
}

export interface DBFund {
    // key
    id: number;
    // 免费奖励
    free: IRes;
    // 高级奖励
    advance: IRes;
    // 豪华奖励
    luxury: IRes;
}

export interface DBSevenCheckIn {
    // id
    id: number;
    // 奖励
    reward: Array<IRes>;
}

export interface DBMission {
    // id
    id: number;
    // 模式
    mode: number;
    // 路由路径
    routePath: string;
}

export interface DBDailyMission {
    // id
    id: number;
    // 任务ID
    missionId: number;
    // 完成条件
    condition: number;
    // 奖励
    reward: number;
    // 渠道
    channel: Array<number>;
}

export interface DBWeeklyMission {
    // id
    id: number;
    // 任务ID
    missionId: number;
    // 完成条件
    condition: number;
    // 奖励
    reward: number;
    // 渠道
    channel: Array<number>;
}

export interface DBAchievementMission {
    // id
    id: number;
    // 任务ID
    missionId: number;
    // 完成条件
    condition: Array<number>;
    // 奖励
    reward: IRes;
    // 渠道
    channel: Array<number>;
}

export interface DBDailyMissionProgress {
    // 进度
    progress: number;
    // 日常任务进度奖励
    rewards: Array<IRes>;
}

export interface DBWeeklyMissionProgress {
    // 进度
    progress: number;
    // 日常任务进度奖励
    rewards: Array<IRes>;
}

export interface DBCurrencyShop {
    // key
    id: number;
    // 商品
    item: IRes;
    // 购买上限
    buyCap: number;
    // 购买方式
    buyMethod: number;
    // 首次免费
    firstFree: boolean;
    // 折扣
    sale: number;
    // icon
    icon: string;
}

export interface DBMiniGame {
    // id
    id: number;
    // 名称
    name: string;
    // bundleName
    bundleName: string;
    // sceneName
    sceneName: string;
    // 实际难度总数
    realTotalDifficulty: number;
    // 难度总数
    totalDifficulty: number;
    // 冷却时间(分钟)
    cd: number;
}

export interface DBChapter {
    // key
    id: number;
    // 名称
    name: string;
    // 关卡总数
    totalStages: number;
    // 预制体
    prefab: string;
    // 地图预制体
    map: string;
    // 脚本
    script: string;
    // 敌人列表
    emyList: Array<number>;
    // 基础攻击
    atkBase: number;
    // 攻击成长
    atkGrow: number;
    // 基础生命
    hpBase: number;
    // 生命成长
    hpGrow: number;
    // 通关奖励
    passRewards: Array<IRes>;
    // 首通奖励
    firstRewards: Array<IRes>;
    // 章节奖励
    stageRewards: Array<IChapterChest>;
}

export interface DBMaze {
    // key
    id: number;
    // 类型
    type: number;
    // 难度
    level: number;
    // 名称
    name: string;
    // 关卡总数
    totalStages: number;
    // 地图预制体
    map: string;
    // 脚本
    script: string;
    // 敌人列表
    emyList: Array<number>;
    // 基础攻击
    atkBase: number;
    // 攻击成长
    atkGrow: number;
    // 基础生命
    hpBase: number;
    // 生命成长
    hpGrow: number;
    // 通关奖励
    passRewards: Array<IRes>;
}

export interface DBSummon {
    // id
    id: number;
    // 名称
    name: string;
    // 获取方式
    getMethod: number;
    // 消耗
    cost: IRes;
    // 经验值
    exp: number;
    // 广告时间（分钟）
    adTime: number;
}

export interface DBSummonInfo {
    // 召唤等级
    lv: number;
    // 普通召唤
    summon0: Array<IRes>;
    // 高级召唤
    summon1: Array<IRes>;
    // 经验
    exp: number;
}

export interface DBUnlockFunc {
    // id
    id: number;
    // 解锁类型
    type: number;
    // 解锁参数
    params: Array<number>;
}

export interface DbConstNumber {
    // 编号
    key: string;
    // 值
    value: number;
}

export interface DbConstArray {
    // 编号
    key: string;
    // 值
    value: Array<number>;
}

export interface DbConstRes {
    // 编号
    key: string;
    // 值
    value: Array<IRes>;
}

export interface DbChannel {
    // 编号
    id: number;
    // 平台
    channel: number;
    // AppId
    appId: string;
    // AppKey
    appKey: string;
    // 字典前缀
    dictKeyPrefix: string;
    // OfferId
    offerId: string;
    // 内购开关
    isIAPOn: number;
    // 价格类型
    priceId: number;
    // 测试支付
    payTest: boolean;
    // 支付类型
    payType: number;
    // 游戏币价格
    coinPrice: number;
    // 服务器地址
    serverAddress: string;
    // 策略地址
    address: string;
    // 区服
    serverArea: string;
    // 聊天服务器
    chatServer: string;
    // 游戏版本
    gameVer: number;
    // 版本号
    version: string;
    // 横幅广告
    banner: IAdConfig;
    // 激励视频广告
    reward: Array<string>;
    // 插屏广告
    inter: string;
    // 微信手Q定制广告
    custom: Array<IAdConfig>;
    // 更多游戏广告
    gamePortal: IAdConfig;
    // 游戏圈（微信）
    gameClub: IStyle;
    // 客服（抖音）
    service: IStyle;
    // 抖音录屏
    record: IRecord;
}

export interface DBEnemyTeam {
    // id
    id: number;
    // 队伍ID
    team_id: string;
    // 生命
    hp: number;
    // 高度
    height: number;
    // 预制体
    prefab: string;
    // 是否BOSS
    boss: number;
}

export interface DB_Buff {
    // id
    id: number;
    // buff类型左
    l_type: number;
    // buff数字
    l_num: number;
    // 操作符
    l_op: number;
    // buff类型右
    r_type: number;
    // buff数字
    r_num: number;
    // 操作符
    r_op: number;
}

export interface DB_Rank0 {
    // id
    id: number;
    // 是否是buff
    is_board_pair: number;
    // 对应的演员id
    actor_id: number;
    // 屏幕滚动x像素后生成actor
    scroll: number;
}

export interface DB_Rank1 {
    // id
    id: number;
    // 是否是buff
    is_board_pair: number;
    // 对应的演员id
    actor_id: number;
    // 屏幕滚动x像素后生成actor
    scroll: number;
}

export interface DB_Rank2 {
    // id
    id: number;
    // 是否是buff
    is_board_pair: number;
    // 对应的演员id
    actor_id: number;
    // 屏幕滚动x像素后生成actor
    scroll: number;
}

export interface DB_Rank3 {
    // id
    id: number;
    // 是否是buff
    is_board_pair: number;
    // 对应的演员id
    actor_id: number;
    // 屏幕滚动x像素后生成actor
    scroll: number;
}

export interface Sheet4 {
    // id
    id: number;
    // 是否是buff
    is_board_pair: number;
    // 对应的演员id
    actor_id: number;
    // 屏幕滚动x像素后生成actor
    scroll: number;
}

export interface dict_main {
    // 编号
    key: string;
    // 简体中文
    value_cn: string;
    // 繁体中文
    value_hk: string;
    // 英文
    value_en: string;
    // 渠道
    channel: number;
}

export interface dict_icon {
    // 编号
    key: string;
    // 简体中文
    value_cn: string;
    // 繁体中文
    value_hk: string;
    // 英文
    value_en: string;
    // 是否分渠道
    channel: number;
}

export interface BuffData {
    // id
    id: number;
    // 类型
    type: number;
    // 叠加上限
    max: number;
    // 触发几率
    per: number;
    // 属性
    props: Array<number>;
    // 值
    values: Array<number>;
    // 属性
    duration: number;
    // 高度
    height: number;
    // 特效预制体
    prefab: string;
}

export interface PuzzleItemData {
    // id
    id: number;
    // 类型
    type: number;
    // 宽
    w: number;
    // 高
    h: number;
    // 数据
    data: Array<number>;
    // 预制体
    prefab: string;
    // 权重
    weight: number;
    // 次数
    count: number;
}

export interface EnemyModuleData {
    // id
    id: number;
    // 类型
    type: number;
    // 速度
    speed: number;
    // 模型
    model: string;
    // 攻击系数
    atk: number;
    // 生命系数
    hp: number;
    // 技能数组
    skills: Array<number>;
    // 影子
    shadow: string;
    // ai脚本
    aiScript: string;
    // 中心Y
    centerY: number;
    // 血条Y
    hpY: number;
    // 缩放
    scale: number;
}

export interface DbPay {
    // 编号
    id: number;
    // 产品id
    prodId: string;
    // 名字
    name: string;
    // 立即获得的资源
    reward1: Array<IRes>;
    // 每天领取的资源
    reward2: Array<IRes>;
    // 前置
    perp: number;
    // 首充双倍
    firstDouble: boolean;
    // 值
    price: number;
    // 限购类型
    limitType: number;
    // 限购次数
    limitCount: number;
    // 售出状态
    soldStatus: number;
}

export interface DbPrice {
    // 编号
    id: number;
    // 值
    cny: number;
    // 值
    usd: number;
}

export interface DBHeroProperty {
    // key
    key: number;
    // 初始值
    init: number;
    // 单位
    unit: string;
}

export interface DBTeamProperty {
    // key
    key: number;
    // 初始值
    init: number;
    // 单位
    unit: string;
}

export interface SkillData {
    // id
    id: number;
    // 介绍
    desc: string;
    // 名字
    name: string;
    // 图标
    icon: string;
    // 类型
    type: number;
    // 召唤id
    sId: number;
    // 射程
    range: number;
    // 瞄准类型
    aimType: number;
    // 系数
    per: number;
    // 技能cd
    cd: number;
    // 自己buff
    buff: Array<number>;
    // 子弹类型
    bltType: number;
    // 子弹id
    bulletId: Array<number>;
    // 额外技能
    exSkill: number;
    // 连斩几率
    comboPer: number;
    // 每发数量
    bltNum: number;
    // 弹夹数
    shot: number;
    // 每发cd
    shotCD: number;
    // 子弹夹角
    bltAngle: number;
    // 夹角递增
    addAngle: number;
    // 发射高度
    shootH: number;
    // cd清除
    clearCD: number;
}

export interface SummonData {
    // id
    id: number;
    // 类型
    type: number;
    // id
    mId: number;
    // 数量
    num: number;
    // 生命周期
    life: number;
    // 半径
    range: number;
}

export interface BulletData {
    // id
    id: number;
    // 速度
    speed: number;
    // 角速度
    aSpeed: number;
    // 生命周期
    life: number;
    // 移动类型
    moveType: number;
    // 瞄准类型
    aimType: number;
    // 伤害系数
    per: number;
    // buff额外伤害
    exPer: Array<number>;
    // 模型
    model: string;
    // 穿刺
    through: number;
    // 打击特效
    hitEff: string;
    // buffId
    buff: Array<number>;
    // 子母弹id
    subId: number;
    // 母弹发射间隔
    subInv: number;
    // 子母弹延时
    subDelay: number;
    // 图层
    dl: number;
    // 自动旋转
    rotate: boolean;
    // 功能
    func: Array<number>;
}

export interface DbBattleAbility {
    // id
    id: number;
    // 稀有度
    rare: number;
    // 类型
    tpye: number;
    // 英雄ID
    heroId: number;
    // 等级
    lv: number;
    // 次数
    count: number;
    // 介绍
    desc: string;
    // 图标
    icon: string;
    // 前置ID
    prepose: number;
    // 属性
    property: IProperty;
    // 技能修改
    skillEdit: Array<number>;
}

export interface DropData {
    // id
    id: number;
    // 掉落类型
    type: number;
    // 资源类型
    resType: number;
    // 资源Id数组
    resId: Array<number>;
    // 0几率|1权重|2数量
    per: Array<number>;
}

export interface DBHeroData {
    // //
    id: number;
    // 名字
    name: string;
    // 英雄类型
    heroType: number;
    // 职业类型
    occ: number;
    // 品质
    rare: number;
    // 格子ID
    grid: number;
    // 格子图标
    gridIcon: string;
    // 普攻范围
    range: number;
    // 自定义解锁描述
    customUnlockDesc: string;
    // 解锁章节
    unlock: number;
    // 技能1数组
    skills: Array<number>;
    // 能力数组
    abilities: Array<number>;
    // 模型
    model: string;
    // 图标
    icon: string;
    // 脚本
    script: string;
    // 移动速度
    moveSpeed: number;
    // 普攻速度
    attackSpeed: number;
    // 生命属性
    property0: HeroProperty;
    // 主属性
    property1: HeroProperty;
    // 冷却属性
    property2: HeroProperty;
    // 价格
    price: number;
}

export interface DBSummoner {
    // //
    name: string;
    // 职业类型
    occ: number;
    // 品质
    rare: number;
    // 自定义解锁描述
    customUnlockDesc: string;
    // 解锁章节
    unlock: number;
    // 技能1数组
    skills: Array<number>;
    // 能力数组
    abilities: Array<number>;
    // 图标
    icon: string;
    // 半身头像
    iconHalf: string;
    // 全身图标
    iconFull: string;
    // 主属性
    property: HeroProperty;
    // 价格
    price: number;
    // 技能音效
    sound: string;
}

export interface DBHeroUpgrade {
    // id
    id: number;
    // 稀有度
    rare: number;
    // 英雄等级
    lv: number;
    // 碎片
    frag: number;
    // 金币
    price: number;
}

export interface DBCurrencyData {
    // id
    id: number;
    // 名字
    name: string;
    // 图标
    icon: string;
    // 介绍
    desc: string;
    // 初始货币
    init: number;
    // 稀有度
    rare: number;
    // 钻石价格
    price: number;
    // 使用参数
    useParams: Array<number>;
    // 路由路径
    routePath: string;
}

export interface DBDailyCurrencyData {
    // 货币id
    id: number;
    // 回复数量
    recover: number;
    // 上限
    limit: number;
}

